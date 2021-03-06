﻿using System.Collections.Generic;
using System.Linq;
using Moq;

namespace Xenon.Tests.ExtensionMethods
{
	public static class XenonBrowserExtensionMethods
	{
		public static void SetupFindElementsByCssSelector( this Mock<IXenonBrowser> browser, string cssSelector, Mock<IXenonElement> element, int returnElementAfterCalls = 0 )
		{
			var timesCalled = 0;
			browser.Setup( x => x.FindElementsByCssSelector( cssSelector ) )
				   .Returns( () => ++timesCalled < returnElementAfterCalls ? new List<IXenonElement>() : new List<IXenonElement>
				   {
					   element.Object
				   } );
		}

		public static void SetupFindElementsByXPath( this Mock<IXenonBrowser> browser, string xpath, params Mock<IXenonElement>[] elements  )
		{
			browser
				.Setup( x => x.FindElementsByXPath( It.IsAny<string>() ) )
				.Returns( elements.Select( x => x.Object ) );

		}
	}
}