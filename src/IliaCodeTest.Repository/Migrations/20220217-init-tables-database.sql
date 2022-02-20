drop table if exists [dbo].[tb_customer];

/*==============================================================*/
/* Table: TB_CUSTOMER                                              */
/*==============================================================*/
create table [dbo].[tb_customer] 
(
   [pk-customer] uniqueidentifier not null
		constraint [ix-customer-pk-customer]
		primary key nonclustered,

   [name] varchar(100) not null,
   [email] varchar (200) not null
		constraint [ix-customer-email] unique([email]),
   [main-document] varchar (11) not null
		constraint [ix-customer-main-document] unique([main-document])

)

drop table if exists [dbo].[tb_order];

/*==============================================================*/
/* Table: TB_ORDER                                              */
/*==============================================================*/
create table [dbo].[tb_order] 
(
   [pk-order] uniqueidentifier not null
		constraint [ix-order-pk-order]
		primary key nonclustered,
   [fk-consumer] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[tb_customer]([pk-customer]),
   [description] varchar(100) not null
	    constraint [ix-order-description] unique([description]),
   [order-status] tinyint not null,
   [created-at] datetime not null,
   [price] decimal not null,

)