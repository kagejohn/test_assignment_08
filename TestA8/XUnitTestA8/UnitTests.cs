using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestA8.Models;
using Xunit;

namespace XUnitTestA8
{
    public class UnitTests
    {
        [Fact]
        public void EnterOrder()
        {
            Order order = new Order{Pizza = Menu.Read()[50], OrderTime = DateTime.Now, PickupTime = DateTime.Now.AddDays(10), Paid = true};

            OrderSystem.EnterOrder(order);

            Assert.Contains(order, OrderSystem.GetAllOrders());
        }

        [Fact]
        public void GetAllOrders()
        {
            Order order = new Order { Pizza = Menu.Read()[50], OrderTime = DateTime.Now, PickupTime = DateTime.Now.AddDays(10), Paid = true };

            OrderSystem.EnterOrder(order);

            Assert.NotEmpty(OrderSystem.GetAllOrders());
        }

        [Fact]
        public void RemoveOrder()
        {
            Order order = new Order { Pizza = Menu.Read()[50], OrderTime = DateTime.Now, PickupTime = DateTime.Now.AddDays(10), Paid = true };

            OrderSystem.EnterOrder(order);

            OrderSystem.RemoveOrder(order);

            Assert.DoesNotContain(order, OrderSystem.GetAllOrders());
        }
    }
}
