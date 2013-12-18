using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.ActionFilters;
using Jobney.EF.Learning.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jobney.EF.Learning.Models;
using Envoc.Core.UnitTests.Extensions;
using NSubstitute;
using NSubstitute.Core;

namespace Jobney.EF.Learning.UnitTests.RequiredTokenContainer
{
    [TestClass]
    public class RequiredTokenTests
    {
        private IRepository<ApiToken> tokenService;
        private RequireToken filter;
        private AuthorizationContext filterContextMock;
        private IUnitOfWork uow;

        [TestInitialize]
        public void Init()
        {
            SetupFilterContext();
            SetupSubstitutions();

            filter = new RequireToken(uow);
        }
        
        [TestMethod]
        public void FakingTokens_WorksCorrectly()
        {
            // Act
            var tokens = tokenService.Query().FirstOrDefault(t => t.Key == "1234ASDF");

            // Assert
            tokens.ShouldNotBeNull();
        }

        [TestMethod]
        public void Fails_WhenNoHeadersSet()
        {
            // Arrange
            ((HttpContextBase)filterContextMock.HttpContext).Request.Headers.Returns(info => new NameValueCollection { { "", "" } });
            
            // Act
            var result = filter.ValidateHeaderToken(filterContextMock.HttpContext);

            // Assert
            result.ShouldBe(false);
        }

        [TestMethod]
        public void Passes_WhenHeadersValid()
        {
            // Arrange
            ((HttpContextBase)filterContextMock.HttpContext).Request.Headers.Returns(info => new NameValueCollection { { "X-Api-Token", "1234ASDF" } });

            // Act
            var result = filter.ValidateHeaderToken(filterContextMock.HttpContext);

            // Assert
            result.ShouldBe(true);
        }

        [TestMethod]
        public void Fail_WhenHeadersInvalid()
        {
            // Arrange
            ((HttpContextBase)filterContextMock.HttpContext).Request.Headers.Returns(info => new NameValueCollection { { "X-Api-Token", "XXXXXXX" } });

            // Act
            var result = filter.ValidateHeaderToken(filterContextMock.HttpContext);

            // Assert
            result.ShouldBe(false);
        }

        private IQueryable<ApiToken> FakeTokens(CallInfo callInfo)
        {
            var list = new List<ApiToken>
            {
                new ApiToken{Id = 1, Key = "1234ASDF", UserId = 1, Created = DateTime.Now.AddMinutes(-1), ValidUntil = DateTime.Now.AddDays(30)},
                new ApiToken{Id = 1, Key = "2345ASDF", UserId = 1, Created = DateTime.Now.AddMinutes(-1), ValidUntil = DateTime.Now.AddDays(30)},
                new ApiToken{Id = 1, Key = "3456ASDF", UserId = 2, Created = DateTime.Now.AddMinutes(-1), ValidUntil = DateTime.Now.AddDays(30)}
            };
            return list.AsQueryable();
        }

        private void SetupFilterContext()
        {
            filterContextMock = Substitute.For<AuthorizationContext>();
            filterContextMock.RequestContext = Substitute.For<RequestContext>();
        }

        private void SetupSubstitutions()
        {
            uow = Substitute.For<IUnitOfWork>();

            tokenService = Substitute.For<IRepository<ApiToken>>();
            tokenService.Query().Returns(FakeTokens);

            uow.GetRepository<ApiToken>().Returns(tokenService);
        }
    }
}