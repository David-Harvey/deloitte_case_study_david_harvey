using Machine.Specifications;
using System;

namespace DeloitteCaseStudy_DavidHarvey.Tests.FileProviderTests
{
    [Subject("FileProvider")]

    #region .ValidateFile Tests

    class when_I_call_ValidateFile_with_an_empty_file_path
    {
        private static IFileProvider provider = new FileProvider();
        private static Exception result = null;

        Because of = () => result = Catch.Exception(() => provider.ValidateFile());

        It should_return_an_exception_stating_a_full_path_must_be_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("Full path to file must be provided.");
        };
    }

    #endregion
}
