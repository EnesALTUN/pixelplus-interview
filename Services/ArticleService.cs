using PixelPlusMulakat.Areas.Admin.Models.ViewModels;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Interfaces.Services;
using PixelPlusMulakat.Models;
using System;
using System.Collections.Generic;

namespace PixelPlusMulakat.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IGenericRepository<Status> _statusRepository;
        private readonly IGenericRepository<Article> _articleRepository;
        private readonly IHelperService _helperService;
        public ArticleService(IGenericRepository<Category> categoryRepository, IGenericRepository<Users> userRepository, IGenericRepository<Status> statusRepository, IGenericRepository<Article> articleRepository, IHelperService helperService)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _statusRepository = statusRepository;
            _articleRepository = articleRepository;
            _helperService = helperService;
        }

        public ArticleCreateVM Create()
        {
            ArticleCreateVM article = new ArticleCreateVM
            {
                Categories = _categoryRepository.GetAll(),
                Statuses = _statusRepository.GetAll()
            };

            return article;
        }

        public bool Insert(Article article, string userEmail)
        {
            try
            {
                Users user = _userRepository.GetByCriteria(
                    filter => filter.Email.Contains(userEmail)
                );

                article.CreatorId = user.Id;
                article.CreatedDate = DateTime.Now;

                _articleRepository.Insert(article);
                _articleRepository.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ArticleVM ArticleDetails(int? id)
        {
            Article article = _articleRepository.GetById(id);

            if (article != null)
            {
                ArticleVM articleVM = new ArticleVM
                {
                    Article = article,
                    CategoryName = _categoryRepository.GetById(article.CategoryId).Name,
                    Creator = _userRepository.GetById(article.CreatorId)
                };

                return articleVM;
            }

            return null;

        }

        public List<ArticleVM> ArticleDetails(List<Article> articles, int length)
        {
            if (articles == null) return null;

            List<ArticleVM> articlesVM = new List<ArticleVM>();

            foreach (var article in articles)
            {
                ArticleVM articleVM = new ArticleVM
                {
                    Article = article,
                    CategoryName = _categoryRepository.GetById(article.CategoryId).Name,
                    Creator = _userRepository.GetById(article.CreatorId),
                    Status = _statusRepository.GetById(article.StatusId).Name
                };

                articleVM.Article.Content = _helperService.ShortenText(articleVM.Article.Content, (length != -1) ? length : articleVM.Article.Content.Length);

                articlesVM.Add(articleVM);
            }

            return articlesVM;
        }

        public ArticleCreateVM Update(Article article)
        {
            ArticleCreateVM articleCreateVM = new ArticleCreateVM
            {
                Article = article,
                Categories = _categoryRepository.GetAll(),
                Statuses = _statusRepository.GetAll()
            };

            return articleCreateVM;
        }
    }
}