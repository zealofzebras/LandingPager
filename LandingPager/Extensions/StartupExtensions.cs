using LandingPager.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddLandingPager(this IServiceCollection services)
        {
            return services.AddSingleton<IKeywordExtractor, KeywordExtractor>();
        }


        public static IServiceCollection AddLandingPager(this IServiceCollection services, Action<LandingFileRepositoryOptions> landingFileOptions, Action<BlogFileRepositoryOptions> blogFileOptions)
        {
            return AddLandingPager<LandingFileRepository, BlogFileRepository>(services, landingFileOptions, blogFileOptions);

        }


        public static IServiceCollection AddLandingPagerWithSpecificLandingRepository<TLandingFileRepository>(this IServiceCollection services, Action<LandingFileRepositoryOptions> landingFileOptions, Action<BlogFileRepositoryOptions> blogFileOptions) where TLandingFileRepository : class, ILandingRepository
        {
            return AddLandingPager<TLandingFileRepository, BlogFileRepository>(services, landingFileOptions, blogFileOptions);

        }

        public static IServiceCollection AddLandingPagerWithSpecificBlogRepository<TBlogFileRepository>(this IServiceCollection services, Action<LandingFileRepositoryOptions> landingFileOptions, Action<BlogFileRepositoryOptions> blogFileOptions) where TBlogFileRepository : class, IBlogRepository
        {
            return AddLandingPager<LandingFileRepository, TBlogFileRepository>(services, landingFileOptions, blogFileOptions);

        }

        public static IServiceCollection AddLandingPager<TLandingFileRepository, TBlogFileRepository>(this IServiceCollection services, Action<LandingFileRepositoryOptions> landingFileOptions, Action<BlogFileRepositoryOptions> blogFileOptions) where TLandingFileRepository : class, ILandingRepository where TBlogFileRepository : class, IBlogRepository
        {

            if (landingFileOptions != null)
                services.Configure(landingFileOptions);

            if (blogFileOptions != null)
                services.Configure(blogFileOptions);

            return AddLandingPager<TLandingFileRepository, TBlogFileRepository>(services);
        }

        public static IServiceCollection AddLandingPager<TLandingFileRepository, TBlogFileRepository>(IServiceCollection services)
            where TLandingFileRepository : class, ILandingRepository
            where TBlogFileRepository : class, IBlogRepository
        {
            AddLandingPager(services);

            services.AddSingleton<ILandingRepository, TLandingFileRepository>();

            return services.AddSingleton<IBlogRepository, TBlogFileRepository>();
        }

        public static PageConventionCollection SetBlogPath(this PageConventionCollection conventions, string blogName)
        {
            return conventions.SetBlogPath(blogName, blogName);
        }

        public static PageConventionCollection SetBlogPath(this PageConventionCollection conventions, string blogPostName, string blogIndexName)
        {
            if (blogIndexName.ToLower() != "blog")
                conventions.AddAreaPageRoute("Blog", "/Index", blogIndexName);

            if (blogPostName.ToLower() != "blog")
                conventions.AddAreaPageRoute("Blog", "/Index", $"{blogPostName}/{{title}}");

            return conventions;
        }


        public static PageConventionCollection SetFeaturesPath(this PageConventionCollection conventions, string featuresName)
        {
            return conventions.SetFeaturesPath(featuresName, featuresName);
        }

        public static PageConventionCollection SetFeaturesPath(this PageConventionCollection conventions, string featureItemName, string featureIndexName)
        {
            if (featureIndexName.ToLower() != "feature")
                conventions.AddAreaPageRoute("Landing", "/FeaturePage", featureIndexName);

            if (featureItemName.ToLower() != "feature")
                conventions.AddAreaPageRoute("Landing", "/FeaturePage", $"{featureItemName}/{{title}}");

            return conventions;
        }

        public static PageConventionCollection SetCompetitorsPath(this PageConventionCollection conventions, string competitorsName)
        {
            return conventions.SetCompetitorsPath(competitorsName, competitorsName);
        }

        public static PageConventionCollection SetCompetitorsPath(this PageConventionCollection conventions, string competitorItemName, string competitorIndexName)
        {
            if (competitorIndexName.ToLower() != "compare-to")
                conventions.AddAreaPageRoute("Landing", "/CompetitorPage", competitorIndexName);

            if (competitorItemName.ToLower() != "compare-to")
                conventions.AddAreaPageRoute("Landing", "/CompetitorPage", $"{competitorItemName}/{{title}}");

            return conventions;
        }

        public static void UseLandingPager(this IApplicationBuilder builder)
        {

            // Only init the blog posts AFTER all services are initialized
            var serviceProvider = builder.ApplicationServices;
            var blogRepository = serviceProvider.GetService(typeof(IBlogRepository));
            if (blogRepository is BlogFileRepository blogFileRepository)
                blogFileRepository.Init();

        }





    }
}
