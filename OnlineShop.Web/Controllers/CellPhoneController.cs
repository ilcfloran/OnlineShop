using OnlineShop.Models;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Http;

namespace OnlineShop.Web.Controllers
{
    public class CellPhoneController : BaseController
    {

        const int PageSize = 5;

        private IQueryable<DefaultCellPhoneViewModel> GetAllCellPhones()
        {
            var cells = this.Data.CellPhones.All().Select(x => new DefaultCellPhoneViewModel {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Model = x.Model,
                Manufacturer = x.Manufacturer.Name,
                Price = x.Price
            }).OrderBy(x => x.Id);
            return cells;
        }

        // added to show list of available items to manage
        public ActionResult ViewList()
        {
            var viewModel = this.Data.CellPhones.All().Select(x => new DefaultCellPhoneViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Model = x.Model,
                Manufacturer = x.Manufacturer.Name,
                Price = x.Price
            }).OrderBy(x => x.Id);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult SubView(string query)
        {

            if (string.IsNullOrEmpty(query.Trim()))
            {
                var viewModel = this.Data.CellPhones.All().Select(x => new DefaultCellPhoneViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Model = x.Model,
                    Manufacturer = x.Manufacturer.Name,
                    Price = x.Price
                }).OrderBy(x => x.Id);
                return PartialView("_ViewModel", viewModel);
            }
            else
            {
                var viewModel = this.Data.CellPhones.All().Where(z => z.Manufacturer.Name.ToLower().Contains(query.ToLower())).Select(x => new DefaultCellPhoneViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Model = x.Model,
                    Manufacturer = x.Manufacturer.Name,
                    Price = x.Price
                }).OrderBy(x => x.Id);
                return PartialView("_ViewModel", viewModel);
            }
        }

        [Authorize]
        public ActionResult List(int? id)
        {

            int pageNumber = id.GetValueOrDefault(1);
     
            var viewModel = GetAllCellPhones().Skip((pageNumber - 1) * PageSize).Take(PageSize);

            ViewBag.pages = Math.Ceiling((double)GetAllCellPhones().Count() / PageSize);

            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var userName = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    CellPhoneId = commentModel.CellPhoneId,

                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUserName = userName, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        public ActionResult Details(int id)
        {
            var sampleViewModel = this.Data.CellPhones.All().Where(x => x.Id == id)
                .Select(x => new CellPhoneDetailsViewModel
                {
                    Id = x.Id,
                    AdditionalParts = x.AdditionalParts,
                    Comments = x.Comment.Select(z => new CommentViewModel
                    {
                        AuthorUserName = z.Author.UserName, Content = z.Content
                    }),
                    Description = x.Description,
                    Storage = x.Storage,
                    ManufacturerName = x.Manufacturer.Name,
                    ImageUrl = x.ImageUrl,
                    Model = x.Model,
                    Display = x.Display,
                    Price = x.Price,
                    Ram = x.Ram
                }).FirstOrDefault();

            return View(sampleViewModel);
        }
    }
}