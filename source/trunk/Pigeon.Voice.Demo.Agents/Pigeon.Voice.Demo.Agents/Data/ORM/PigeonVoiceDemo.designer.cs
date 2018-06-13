﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pigeon.Voice.Demo.Agents.Data.ORM
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PigeonVoiceDemo")]
	public partial class PigeonVoiceDemoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPickItem(PickItem instance);
    partial void UpdatePickItem(PickItem instance);
    partial void DeletePickItem(PickItem instance);
    partial void InsertPickList(PickList instance);
    partial void UpdatePickList(PickList instance);
    partial void DeletePickList(PickList instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public PigeonVoiceDemoDataContext() : 
				base(global::Pigeon.Voice.Demo.Agents.Properties.Settings.Default.PigeonVoiceDemoConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PigeonVoiceDemoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PigeonVoiceDemoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PigeonVoiceDemoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PigeonVoiceDemoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<PickItem> PickItems
		{
			get
			{
				return this.GetTable<PickItem>();
			}
		}
		
		public System.Data.Linq.Table<PickList> PickLists
		{
			get
			{
				return this.GetTable<PickList>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PickItem")]
	public partial class PickItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _PickItemId;
		
		private System.Guid _PickListId;
		
		private string _Sku;
		
		private string _Location;
		
		private string _CheckDigits;
		
		private int _QuantityToPick;
		
		private string _Description;
		
		private System.Nullable<int> _QuantityPicked;
		
		private System.Nullable<char> _PickStatusCode;
		
		private System.Nullable<System.Guid> _PickedByUserId;
		
		private string _PickedByUserName;
		
		private System.DateTime _DateCreated;
		
		private EntityRef<PickList> _PickList;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPickItemIdChanging(System.Guid value);
    partial void OnPickItemIdChanged();
    partial void OnPickListIdChanging(System.Guid value);
    partial void OnPickListIdChanged();
    partial void OnSkuChanging(string value);
    partial void OnSkuChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnCheckDigitsChanging(string value);
    partial void OnCheckDigitsChanged();
    partial void OnQuantityToPickChanging(int value);
    partial void OnQuantityToPickChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnQuantityPickedChanging(System.Nullable<int> value);
    partial void OnQuantityPickedChanged();
    partial void OnPickStatusCodeChanging(System.Nullable<char> value);
    partial void OnPickStatusCodeChanged();
    partial void OnPickedByUserIdChanging(System.Nullable<System.Guid> value);
    partial void OnPickedByUserIdChanged();
    partial void OnPickedByUserNameChanging(string value);
    partial void OnPickedByUserNameChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public PickItem()
		{
			this._PickList = default(EntityRef<PickList>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickItemId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid PickItemId
		{
			get
			{
				return this._PickItemId;
			}
			set
			{
				if ((this._PickItemId != value))
				{
					this.OnPickItemIdChanging(value);
					this.SendPropertyChanging();
					this._PickItemId = value;
					this.SendPropertyChanged("PickItemId");
					this.OnPickItemIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickListId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid PickListId
		{
			get
			{
				return this._PickListId;
			}
			set
			{
				if ((this._PickListId != value))
				{
					if (this._PickList.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPickListIdChanging(value);
					this.SendPropertyChanging();
					this._PickListId = value;
					this.SendPropertyChanged("PickListId");
					this.OnPickListIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sku", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Sku
		{
			get
			{
				return this._Sku;
			}
			set
			{
				if ((this._Sku != value))
				{
					this.OnSkuChanging(value);
					this.SendPropertyChanging();
					this._Sku = value;
					this.SendPropertyChanged("Sku");
					this.OnSkuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckDigits", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CheckDigits
		{
			get
			{
				return this._CheckDigits;
			}
			set
			{
				if ((this._CheckDigits != value))
				{
					this.OnCheckDigitsChanging(value);
					this.SendPropertyChanging();
					this._CheckDigits = value;
					this.SendPropertyChanged("CheckDigits");
					this.OnCheckDigitsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuantityToPick", DbType="Int NOT NULL")]
		public int QuantityToPick
		{
			get
			{
				return this._QuantityToPick;
			}
			set
			{
				if ((this._QuantityToPick != value))
				{
					this.OnQuantityToPickChanging(value);
					this.SendPropertyChanging();
					this._QuantityToPick = value;
					this.SendPropertyChanged("QuantityToPick");
					this.OnQuantityToPickChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuantityPicked", DbType="Int")]
		public System.Nullable<int> QuantityPicked
		{
			get
			{
				return this._QuantityPicked;
			}
			set
			{
				if ((this._QuantityPicked != value))
				{
					this.OnQuantityPickedChanging(value);
					this.SendPropertyChanging();
					this._QuantityPicked = value;
					this.SendPropertyChanged("QuantityPicked");
					this.OnQuantityPickedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickStatusCode", DbType="Char(1)")]
		public System.Nullable<char> PickStatusCode
		{
			get
			{
				return this._PickStatusCode;
			}
			set
			{
				if ((this._PickStatusCode != value))
				{
					this.OnPickStatusCodeChanging(value);
					this.SendPropertyChanging();
					this._PickStatusCode = value;
					this.SendPropertyChanged("PickStatusCode");
					this.OnPickStatusCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickedByUserId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> PickedByUserId
		{
			get
			{
				return this._PickedByUserId;
			}
			set
			{
				if ((this._PickedByUserId != value))
				{
					this.OnPickedByUserIdChanging(value);
					this.SendPropertyChanging();
					this._PickedByUserId = value;
					this.SendPropertyChanged("PickedByUserId");
					this.OnPickedByUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickedByUserName", DbType="VarChar(50)")]
		public string PickedByUserName
		{
			get
			{
				return this._PickedByUserName;
			}
			set
			{
				if ((this._PickedByUserName != value))
				{
					this.OnPickedByUserNameChanging(value);
					this.SendPropertyChanging();
					this._PickedByUserName = value;
					this.SendPropertyChanged("PickedByUserName");
					this.OnPickedByUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PickList_PickItem", Storage="_PickList", ThisKey="PickListId", OtherKey="PickListId", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public PickList PickList
		{
			get
			{
				return this._PickList.Entity;
			}
			set
			{
				PickList previousValue = this._PickList.Entity;
				if (((previousValue != value) 
							|| (this._PickList.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PickList.Entity = null;
						previousValue.PickItems.Remove(this);
					}
					this._PickList.Entity = value;
					if ((value != null))
					{
						value.PickItems.Add(this);
						this._PickListId = value.PickListId;
					}
					else
					{
						this._PickListId = default(System.Guid);
					}
					this.SendPropertyChanged("PickList");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PickList")]
	public partial class PickList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _PickListId;
		
		private int _PickListNumber;
		
		private bool _Picked;
		
		private System.DateTime _DateCreated;
		
		private EntitySet<PickItem> _PickItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPickListIdChanging(System.Guid value);
    partial void OnPickListIdChanged();
    partial void OnPickListNumberChanging(int value);
    partial void OnPickListNumberChanged();
    partial void OnPickedChanging(bool value);
    partial void OnPickedChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public PickList()
		{
			this._PickItems = new EntitySet<PickItem>(new Action<PickItem>(this.attach_PickItems), new Action<PickItem>(this.detach_PickItems));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickListId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid PickListId
		{
			get
			{
				return this._PickListId;
			}
			set
			{
				if ((this._PickListId != value))
				{
					this.OnPickListIdChanging(value);
					this.SendPropertyChanging();
					this._PickListId = value;
					this.SendPropertyChanged("PickListId");
					this.OnPickListIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PickListNumber", DbType="Int NOT NULL")]
		public int PickListNumber
		{
			get
			{
				return this._PickListNumber;
			}
			set
			{
				if ((this._PickListNumber != value))
				{
					this.OnPickListNumberChanging(value);
					this.SendPropertyChanging();
					this._PickListNumber = value;
					this.SendPropertyChanged("PickListNumber");
					this.OnPickListNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Picked", DbType="Bit NOT NULL")]
		public bool Picked
		{
			get
			{
				return this._Picked;
			}
			set
			{
				if ((this._Picked != value))
				{
					this.OnPickedChanging(value);
					this.SendPropertyChanging();
					this._Picked = value;
					this.SendPropertyChanged("Picked");
					this.OnPickedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PickList_PickItem", Storage="_PickItems", ThisKey="PickListId", OtherKey="PickListId")]
		public EntitySet<PickItem> PickItems
		{
			get
			{
				return this._PickItems;
			}
			set
			{
				this._PickItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PickItems(PickItem entity)
		{
			this.SendPropertyChanging();
			entity.PickList = this;
		}
		
		private void detach_PickItems(PickItem entity)
		{
			this.SendPropertyChanging();
			entity.PickList = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _UserId;
		
		private string _Username;
		
		private string _Password;
		
		private bool _LoggedIn;
		
		private System.DateTime _DateCreated;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnLoggedInChanging(bool value);
    partial void OnLoggedInChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoggedIn", DbType="Bit NOT NULL")]
		public bool LoggedIn
		{
			get
			{
				return this._LoggedIn;
			}
			set
			{
				if ((this._LoggedIn != value))
				{
					this.OnLoggedInChanging(value);
					this.SendPropertyChanging();
					this._LoggedIn = value;
					this.SendPropertyChanged("LoggedIn");
					this.OnLoggedInChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
