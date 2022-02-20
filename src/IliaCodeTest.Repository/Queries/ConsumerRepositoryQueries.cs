namespace IliaCodeTest.Repository.Queries
{
	public static class ConsumerRepositoryQueries
	{
		public static string AddConsumerQuery = @"INSERT INTO [dbo].[tb_customer]
		(
		[pk-customer],
		[name],
		[email],
		[main-document]
		)

		VALUES
		(
		@Id,
		@Name,
		@Email,
		@MainDocument
		)";

		public static string GetConsumers = @"SELECT [pk-customer] AS [PKCosumer],
		[name],
		[email],
		[main-document] AS [MainDocument] from tb_customer
		WHERE (@Name is null or [name] = @Name)
		and (@Email is null or [email] = @Email)
		and (@MainDocument is null or [main-document] = @MainDocument)
		ORDER BY [pk-customer] desc
		OFFSET (@PageNumber-1)*@PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY";

		public static string GetConsumersWithOrders = @"SELECT c.[pk-customer] AS[PKCosumer],
		c.[name],
		c.[email],
		c.[main-document] AS [MainDocument],
		o.[pk-order] AS [Id],
		o.[description],
		o.[price],
		o.[created-at] AS [CreatedAt],
		o.[order-status] [Status]
		from [tb_customer] c
		left JOIN[tb_order] o on c.[pk-customer] = o.[fk-consumer]
		ORDER BY [pk-customer] desc
		OFFSET (@PageNumber-1)*@PageSize ROWS
		FETCH NEXT @PageSize ROWS ONLY";

	}
}

