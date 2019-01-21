<Query Kind="Statements">
  <Connection>
    <ID>bee6923e-a5d3-4546-a9d1-c90af7442573</ID>
    <Server>PAULKOLOZSV38D1\MSSQLEXPRESS2012</Server>
    <Database>PigeonVoiceDemo</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

PickItems.DeleteAllOnSubmit(PickItems);
PickLists.DeleteAllOnSubmit(PickLists);
Users.DeleteAllOnSubmit(Users);
SubmitChanges();

//Users
User operatorId = new User() { UserId = Guid.NewGuid(), Username = "Operator.Id",Password = "123",LoggedIn = false, DateCreated = DateTime.Now };
Users.InsertOnSubmit(operatorId);

User paul = new User() { UserId = Guid.NewGuid(), Username = "Paul",Password = "123",LoggedIn = false, DateCreated = DateTime.Now };
Users.InsertOnSubmit(paul);

User nic = new User() { UserId = Guid.NewGuid(), Username = "Nic",Password = "123",LoggedIn = false, DateCreated = DateTime.Now };
Users.InsertOnSubmit(nic);

//Pick List 1
PickList list1 = new PickList() { PickListId = Guid.NewGuid(), PickListNumber = 1, Picked = false, DateCreated = DateTime.Now };
PickLists.InsertOnSubmit(list1);

PickItem item1 = new PickItem()
{ 
	PickItemId = Guid.NewGuid(), 
	PickListId = list1.PickListId,
	Sku = "SK01",
	Location = "L01",
	CheckDigits = "212",
	QuantityToPick = 10,
	Description = "Chicken Wings",
	QuantityPicked = null,
	PickedByUserId = null,
	PickedByUserName = null,
	DateCreated = DateTime.Now
};
PickItems.InsertOnSubmit(item1);

PickItem item2 = new PickItem() 
{ 
	PickItemId = Guid.NewGuid(), 
	PickListId = list1.PickListId, 
	Sku = "SK02",
	Location = "L02",
	CheckDigits = "213",
	QuantityToPick = 11,
	Description = "Beef Patties",
	QuantityPicked = null,
	PickedByUserId = null,
	PickedByUserName = null,
	DateCreated = DateTime.Now
};
PickItems.InsertOnSubmit(item2);

//Pick List 2
PickList list2 = new PickList() { PickListId = Guid.NewGuid(), PickListNumber = 2, Picked = false, DateCreated = DateTime.Now };
PickItem item3 = new PickItem() 
{ 
	PickItemId = Guid.NewGuid(), 
	PickListId = list1.PickListId, 
	Sku = "SK03",
	Location = "L03",
	CheckDigits = "214",
	QuantityToPick = 12,
	Description = "Lettuce",
	QuantityPicked = null,
	PickedByUserId = null,
	PickedByUserName = null,
	DateCreated = DateTime.Now
};
PickItems.InsertOnSubmit(item3);

PickItem item4 = new PickItem() 
{ 
	PickItemId = Guid.NewGuid(), 
	PickListId = list1.PickListId, 
	Sku = "SK04",
	Location = "L04",
	CheckDigits = "215",
	QuantityToPick = 13,
	Description = "Potato",
	QuantityPicked = null,
	PickedByUserId = null,
	PickedByUserName = null,
	DateCreated = DateTime.Now
};
PickItems.InsertOnSubmit(item4);
SubmitChanges();

Users.Dump();
PickLists.Dump();
PickItems.OrderBy (pi => pi.Location).Dump();