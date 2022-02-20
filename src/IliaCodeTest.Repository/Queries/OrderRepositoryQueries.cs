namespace IliaCodeTest.Repository.Queries
{
	public static class OrderRepositoryQueries
	{
		public static string RegisterNewOrderRequest = @"INSERT INTO [dbo].[tb_order]
		(
		[pk-order],
		[fk-consumer],
		[description],
		[order-status],
		[created-at],
		[price]
		)

		VALUES
		(
		@Id,
		@IdConsumer,
		@Description,
		1,
		GETDATE(),
		@Price

		)";

		public static string GetOrdersByConsumer = @"SELECT [pk-order] AS [Id],
		[description] AS [Description],
		[order-status] AS [Status],
		[price] AS [Price],
		[created-at] AS [CreatedAt]
		from [tb_order] o

		INNER JOIN [tb_customer] c on o.[fk-consumer] = c.[pk-customer]
		WHERE (@CPF is null or c.[main-document] = @CPF)
		ORDER BY [pk-order] desc
		OFFSET (@PageNumber-1)*@PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY
		";

		public static string UpdateOrderStatus = @"UPDATE [tb_order] SET [order-status] = @OrderStatus
		WHERE [pk-order] = @IdOrder
		";
	}
}

