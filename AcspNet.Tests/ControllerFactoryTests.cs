﻿using AcspNet.Modules;
using AcspNet.Modules.Html;
using AcspNet.Modules.Identity;
using AcspNet.Tests.TestControllers;
using Moq;
using NUnit.Framework;

namespace AcspNet.Tests
{
	[TestFixture]
	public class ControllerFactoryTests
	{
		[Test]
		public void CreateController_DataFilledCorrectly()
		{
			// Arrange

			var modulesContainer = new Mock<ModulesContainer>();
			modulesContainer.SetupProperty(x => x.FileReader, new Mock<IFileReader>().Object);
			modulesContainer.SetupProperty(x => x.Context, new Mock<IAcspContext>().Object);
			modulesContainer.SetupProperty(x => x.DataCollector, new Mock<IDataCollector>().Object);
			modulesContainer.SetupProperty(x => x.Environment, new Mock<IEnvironment>().Object);
			modulesContainer.SetupProperty(x => x.LanguageManager, new Mock<ILanguageManager>().Object);
			modulesContainer.SetupProperty(x => x.StringTable, new Mock<IStringTable>().Object);
			modulesContainer.SetupProperty(x => x.TemplateFactory, new Mock<ITemplateFactory>().Object);
			modulesContainer.SetupProperty(x => x.MessageBox, new Mock<IMessageBox>().Object);

			var htmlWrapper = new Mock<IHtmlWrapper>();
			htmlWrapper.SetupGet(x => x.ListsGenerator).Returns(new Mock<IListsGenerator>().Object);

			modulesContainer.SetupProperty(x => x.Html, htmlWrapper.Object);
			modulesContainer.SetupProperty(x => x.Authentication, new Mock<IAuthentication>().Object);
			modulesContainer.SetupProperty(x => x.Navigator, new Mock<INavigator>().Object);
			modulesContainer.SetupProperty(x => x.IdVerifier, new Mock<IIdVerifier>().Object);
			modulesContainer.SetupProperty(x => x.MessagePage, new Mock<IMessagePage>().Object);

			var viewFactory = new Mock<IViewFactory>();

			// Act

			var factory = new ControllerFactory(modulesContainer.Object, viewFactory.Object);

			var controller = factory.CreateController(typeof(TestController));

			// Assert

			Assert.IsNotNull(controller.FileReader);
			Assert.IsNotNull(controller.Context);
			Assert.IsNotNull(controller.DataCollector);
			Assert.IsNotNull(controller.Environment);
			Assert.IsNotNull(controller.LanguageManager);
			Assert.IsNotNull(controller.StringTable);
			Assert.IsNotNull(controller.TemplateFactory);
			Assert.IsNotNull(controller.ViewFactory);
			Assert.IsNotNull(controller.MessageBox);
			Assert.IsNotNull(controller.Authentication);
			Assert.IsNotNull(controller.Navigator);
			Assert.IsNotNull(controller.IdVerifier);
			Assert.IsNotNull(controller.MessagePage);
		}
	}
}