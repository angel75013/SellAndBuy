using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Services
{
    public class ImagesServices:IService
    {
        private readonly IEfRepository<Image> images;
        private readonly IEfUnitOfWork context;

        public ImagesServices(IEfRepository<Image> images, IEfUnitOfWork context)
        {
            this.images = images;
            this.context = context;
        }

        public void CreateImage(string imageUrl)
        {
            var image = new Image();
           
            image.ImageUrl = imageUrl;

            this.images.Add(image);
            this.context.Commit();

           

        }
    }
}
