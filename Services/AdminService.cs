using PixelPlusMulakat.Areas.Admin.Models.ViewModels;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Interfaces.Services;
using PixelPlusMulakat.Models;
using System;

namespace PixelPlusMulakat.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<Article> _articleRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Users> _userRepository;
        public AdminService(IGenericRepository<Article> articleRepository, IGenericRepository<Category> categoryRepository, IGenericRepository<Users> userRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public AdminPage GetContentCount()
        {
            AdminPage adminPage = new AdminPage
            {
                TotalArticleCount = _articleRepository.GetAll().Count,
                TotalCategoryCount = _categoryRepository.GetAll().Count,
                TotalUserCount = _userRepository.GetAll().Count
            };

            return adminPage;
        }
    }
}
