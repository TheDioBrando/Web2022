using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLearning.Controllers;
using WebApiLearning.Interfaces;
using WebApiLearning.Models;

namespace TestAPI
{

    public class BooksTests
    {
        [Fact]
        public void IndexReturnsAListOfItems()
        {
            var mock = new Mock<IGenericRepository<Books>>();
            mock.Setup(x => x.GetAll()).Returns(GetBooksList().Select(x=> new Books 
            { 
                Id=x.Id,
                Title=x.Title,
                Author=x.Author,
            }));
            var controller = new BooksController(mock.Object);

            var result = controller.GetBooks();

            var list = Assert.IsType<List<BooksDTO>>(result);
            Assert.Equal(GetBooksList().Count, list.Count);
        }

        


        private List<BooksDTO> GetBooksList()
        {
            var books = new List<BooksDTO>
            {
                new BooksDTO{ Id=1, Author = "asd", Title="wer"},
                new BooksDTO{ Id = 2, Author="asdg", Title="eryhf"},
                new BooksDTO{ Id=5, Author = "rth", Title="gbx"}
            };

            return books;
        }
    }
}
