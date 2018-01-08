using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Lambda.Core;


namespace GreetLambda
{
    public class ConfigProvider
    {
        private readonly ILambdaContext _lambdaContext;

        public ConfigProvider(ILambdaContext lambdaContext)
        {
            _lambdaContext = lambdaContext;
        }

        private string GetAccountId()
        {
            return _lambdaContext.InvokedFunctionArn.Split(':')[4];
        }

        public string GetSnsTopic()
        {
            return $"arn:aws:sns:us-east-1:{GetAccountId()}:DestinationTopic";
        }
    }
}
