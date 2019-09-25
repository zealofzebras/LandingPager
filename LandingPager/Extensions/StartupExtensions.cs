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
            return services.AddSingleton<KeywordExtractor>();
        }


        public static IServiceCollection AddLandingPager(this IServiceCollection services, Action<LandingFileRepositoryOptions> landingFileOptions, Action<BlogFileRepositoryOptions> blogFileOptions)
        {
            return AddLandingPager<LandingFileRepository, BlogFileRepository>(services, landingFileOptions, blogFileOptions);

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
            return conventions.AddAreaPageRoute("Blog", "/Index", blogIndexName).AddAreaPageRoute("Blog", "/Index", $"{blogPostName}/{{title}}");
        }


        public static PageConventionCollection SetFeaturesPath(this PageConventionCollection conventions, string featuresName)
        {
            return conventions.SetFeaturesPath(featuresName, featuresName);
        }

        public static PageConventionCollection SetFeaturesPath(this PageConventionCollection conventions, string featureItemName, string featureIndexName)
        {
            return conventions.AddAreaPageRoute("Landing", "/FeaturePage", featureIndexName).AddAreaPageRoute("Landing", "/FeaturePage", $"{featureItemName}/{{title}}");
        }

        public static PageConventionCollection SetCompetitorsPath(this PageConventionCollection conventions, string competitorsName)
        {
            return conventions.SetCompetitorsPath(competitorsName, competitorsName);
        }

        public static PageConventionCollection SetCompetitorsPath(this PageConventionCollection conventions, string competitorItemName, string competitorIndexName)
        {
            return conventions.AddAreaPageRoute("Landing", "/CompetitorPage", competitorIndexName).AddAreaPageRoute("Landing", "/CompetitorPage", $"{competitorItemName}/{{title}}");
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
