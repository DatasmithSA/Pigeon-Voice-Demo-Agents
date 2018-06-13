namespace Pigeon.Voice.Demo.Agents.Data.DB
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Figlut.Server.Toolkit.Data.DB.LINQ;
    using System.Data.Linq;
    using Pigeon.Voice.Demo.Agents.Data.ORM;
    using Pigeon.Voice.Demo.Agents.Configuration;

    #endregion //Using Directives

    public partial class AgentsDBContext : EntityContext
    {
        #region Constructors

        public AgentsDBContext(
            DataContext db,
            LinqFunnelSettings settings,
            bool handleExceptions,
            Type userLinqToSqlType,
            Type serverActionLinqToSqlType,
            Type serverErrorLinqToSqlType) :
            base(db, settings, handleExceptions, userLinqToSqlType, serverActionLinqToSqlType, serverErrorLinqToSqlType)
        {
        }

        #endregion //Constructors

        #region Methods

        public static AgentsDBContext Create()
        {
            return new AgentsDBContext(
                new PigeonVoiceDemoDataContext(),
                new LinqFunnelSettings(
                    AgentsGlobals.Instance.Settings.DatabaseConnectionString,
                    AgentsGlobals.Instance.Settings.DatabaseCommandTimeout),
                false,
                null,
                null,
                null);
        }

        #region Utility Methods

        private User GetUser(string username, string password, bool throwExceptionOnNotFound)
        {
            string usernameLower = username.ToLower();
            User result = (from u in DB.GetTable<User>()
                           where u.Username.ToLower() == usernameLower &&
                           u.Password == password
                           select u).FirstOrDefault();
            if (throwExceptionOnNotFound && result == null)
            {
                throw new NullReferenceException(string.Format("User {0} does not exist.", username));
            }
            return result;
        }

        private User GetUser(string username, bool throwExceptionOnNotFound)
        {
            string usernameLower = username.ToLower();
            User result = (from u in DB.GetTable<User>()
                           where u.Username.ToLower() == usernameLower
                           select u).FirstOrDefault();
            if (throwExceptionOnNotFound && result == null)
            {
                throw new NullReferenceException(string.Format("User {0} does not exist.", username));
            }
            return result;
        }

        private bool PickListCompleted(Guid pickListId)
        {
            return (from item in DB.GetTable<PickItem>()
                    where item.PickListId == pickListId &&
                    !item.PickStatusCode.HasValue
                    select item).Count() == 0;
        }

        #endregion //Utility Methods

        #region Agent Methods

        public void Login(string username, string password)
        {
            User user = GetUser(username, password, false);
            if (user == null)
            {
                throw new Exception("Invalid user name or password.");
            }
            user.LoggedIn = true;
            DB.SubmitChanges();
        }

        public PickList GetPickList(string username)
        {
            PickList result = (from p in DB.GetTable<PickList>()
                               where !p.Picked
                               select p).FirstOrDefault();
            if (result == null)
            {
                throw new Exception("No pick list available.");
            }
            return result;
        }

        public List<PickItem> GetPickListItems(int pickListNumber)
        {
            List<PickItem> result = (from item in DB.GetTable<PickItem>()
                                     join list in DB.GetTable<PickList>() on item.PickListId equals list.PickListId into setList
                                     from listView in setList.DefaultIfEmpty()
                                     where listView.PickListNumber == pickListNumber
                                     orderby item.Location ascending
                                     select item).ToList();
            if (result.Count < 1)
            {
                throw new Exception(string.Format("No items for pick list {0}.", pickListNumber));
            }
            return result;
        }

        public void ConfirmPick(string username, int pickListNumber, string sku, int quantityPicked, char pickStatusCode)
        {
            PickList pickList = (from list in DB.GetTable<PickList>()
                                 where list.PickListNumber == pickListNumber
                                 select list).FirstOrDefault();
            if (pickList == null)
            {
                throw new NullReferenceException(string.Format("Pick list {0} could not be found.", pickListNumber));
            }
            PickItem result = (from item in DB.GetTable<PickItem>()
                               where item.PickListId == pickList.PickListId &&
                               item.Sku == sku
                               select item).FirstOrDefault();
            if (result == null)
            {
                throw new Exception(string.Format("Item with skew {0} on list {1} does not exist.",
                    sku,
                    pickListNumber));
            }
            string usernameLower = username.ToLower();
            User user = GetUser(username, true);
            result.QuantityPicked = quantityPicked;
            result.PickedByUserId = user.UserId;
            result.PickedByUserName = user.Username;
            result.PickStatusCode = pickStatusCode;
            DB.SubmitChanges();
            if (PickListCompleted(pickList.PickListId))
            {
                pickList.Picked = true;
                DB.SubmitChanges();
            }
        }

        public void LogOff(string username)
        {
            User user = GetUser(username, true);
            user.LoggedIn = false;
            DB.SubmitChanges();
        }

        #endregion //Agent Methods

        #endregion //Methods
    }
}