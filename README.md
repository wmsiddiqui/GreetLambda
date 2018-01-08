# GreetLambda
This application is a lambda that is triggered by an incoming SNS message. The lambda takes the message off the sns topic, and creates a hello message using the name on the message. It then publishes a new message on a different SNS topic, which has an email subscribed to it.

A powershell script is used to build, package, and deploy the solution to an S3 Bucket, and then uses the AWS CLI to deploy the stack using CloudFormation.

##ToDo

* The message can be a bit more complex, and can use a serialized JSON object. The app can use a JSON Deserializer and then apply logic to the incoming object. 
* Need a way to parameterize the email address, since right now it is using mine for the subscription. The powershell script would accept a parameter that would then replace the email address in the stack.json file. 
