# GreetLambda
This application is a lambda that is triggered by an incoming SNS message. The lambda takes the message off the sns topic, and creates a hello message using the name on the message. It then publishes a new message on a different SNS topic, which has an email subscribed to it.

A powershell script is used to build, package, and deploy the solution to an S3 Bucket, and then uses the AWS CLI to deploy the stack using CloudFormation.

## The Stack
GreetLambda - Lambda that processes the message
SourceTopic - SNS Topic that triggers the lambda
DestinationTopic - SNS Topic that the lambda publishes too. This has an email subscribed to it.

## The Script
The deploy script first clears out any contents in the deploy folder, it then builds and packages the files, and uploads it to an S3 bucket. It then uses CloudFormation to create the stack, using the Stack.json file as a template. 

## ToDo

* The message can be a bit more complex, and can use a serialized JSON object. The app can use a JSON Deserializer and then apply logic to the incoming object. 
* Need a way to parameterize the email address, since right now it is using mine for the subscription. The powershell script would accept a parameter that would then replace the email address in the stack.json file. 
* Make sure the script doesn't fail if the S3 bucket doesn't exist.
