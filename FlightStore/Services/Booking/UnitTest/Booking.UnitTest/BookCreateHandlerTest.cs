using Booking.Service.Handlers;
using Booking.Service.Handlers.Commands;
using Booking.UnitTest.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;

namespace Booking.UnitTest
{
    [TestClass]
    public class BookCreateHandlerTest
    {
        [TestMethod]
        public void TryToCreateBookWhenDataIsCompleted()
        {
            var context = ApplicationDbContextInMemory.Get();
            var flightId = 1;

            var handler = new BookCreateHandler(context);

            handler.Handle(
                new CreateBookCommand
                {
                    Email = "test@gmail.com",
                    FullName = "Joe Doe",
                    FlightId = flightId,
                    Phone = "3192594058"
                }, new CancellationToken()).Wait();

            var book = context.Books.Single(x => x.FlightId == flightId);

            Assert.IsTrue(!string.IsNullOrEmpty(book.ReservationCode) && book.ReservationCode.Length == 6);

        }
    }
}
