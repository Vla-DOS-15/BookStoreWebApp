using BookStoreWebApp.Interfaces;
using BookStoreWebApp.Models;
using System;

namespace BookStoreWebApp.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly BookContext bookContext;
        private readonly ShopCart shopCart;

        public OrdersRepository(BookContext bookContext, ShopCart shopCart)
        {
            this.bookContext = bookContext;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            bookContext.Orders.Add(order);
            var items = shopCart.ListShopItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    BookId = el.Book.Id,
                    OrderId = order.OrderId,
                    Price = el.Book.Price
                };
                bookContext.Add(orderDetail);
            }
            bookContext.SaveChanges();
        }
    }
}
