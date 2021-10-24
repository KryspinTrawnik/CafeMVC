using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        public OrderRepository(Context context) 
        {
            _context = context;
        }

        public Order GetOrderById(int orderId)
        {
            var order = _context.Orders.AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.ContactDetails)
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == orderId);

            return order;
        }
        public IQueryable<Order> GetAllOpenOrders()
        {
            return _context.Orders.AsNoTracking()
                .Include(x => x.Customer)
                .Include(x=> x.ContactDetails)
                .Include(x=> x.Products)
                .Where(x => x.Status.Name == "Open");

        }
        public void UpdateOrder(Order order)
        {
            _context.Attach(order);
            _context.Entry(order).Property("LeadTime");
            _context.Entry(order).Property("DateOfOrder");
            _context.Entry(order).Property("TotalPrice");
            _context.Entry(order).Property("HasBeenDone");
            _context.Entry(order).Property("Note");
            _context.Entry(order).Collection("ContactDetails");
            _context.Entry(order).Collection("Addresses");
            _context.Entry(order).Collection("Products");
            _context.Entry(order).Property("OrderConfirmation");
            _context.Entry(order).Property("IsCollection");
            _context.SaveChanges();
        }

        public int AddNewOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.Id;
        }

        public IQueryable<Product> GetAllProductsFromOrder(int orderId)
        {
            var productsFromOrder = _context.Orders.AsNoTracking()
                .Include(x => x.Products).FirstOrDefault(x => x.Id == orderId).Products.AsQueryable();
            return productsFromOrder;
        }

        public void AddOrChangeNote(int orderId, string note)
        {
            Order order = _context.Orders.AsNoTracking().FirstOrDefault(x=> x.Id == orderId);
            order.Note = note;
            UpdateOrder(order);
        }

        public void ChangeStatusOfOrder(int orderId, int statusId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            order.Status = _context.Statuses.FirstOrDefault(x => x.Id == statusId);
            UpdateOrder(order);
        }

        public IQueryable<Status> GetAllStatuses()
        {
            return _context.Statuses.AsNoTracking();
        }

        IQueryable<Order> IOrderRepository.GetAllOrders()
        {
            return _context.Orders.AsNoTracking()
                    .Include(x => x.Customer)
                    .Include(x => x.ContactDetails)
                    .Include(x => x.Products);

        }
    }
}
