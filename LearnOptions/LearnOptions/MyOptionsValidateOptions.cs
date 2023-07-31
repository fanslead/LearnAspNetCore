using Microsoft.Extensions.Options;

namespace LearnOptions
{
    public class MyOptionsValidateOptions : IValidateOptions<MyOptions>
    {
        public ValidateOptionsResult Validate(string? name, MyOptions options)
        {
            // 验证 Options 的配置
            if (options.Option1 == null)
            {
                return ValidateOptionsResult.Fail("Option1 must be specified.");
            }
            return ValidateOptionsResult.Success;
        }
    }
}
