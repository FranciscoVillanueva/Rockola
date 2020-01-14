using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rockola.Controllers
{
    public class YoutubeController : Controller
    {
        //GET: Youtube
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchList(string SearchWord)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDugHywJPERkmU_DxB9R0PC8WVD9q-3Xmc",
                ApplicationName = this.GetType().ToString()
            });

            var SearchListRequest = youtubeService.Search.List("snippet");
            SearchListRequest.Q = SearchWord;
            SearchListRequest.MaxResults = 10;

            var SearchListResponse = SearchListRequest.Execute();

            return PartialView("Lista",SearchListResponse.Items);
        }
    }
}