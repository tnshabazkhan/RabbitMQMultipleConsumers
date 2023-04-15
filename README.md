# RabbitMQProducerConsumer

1. This application has the boilerplate code for Multiple Consumers architecture with RabbitMQ using Fanout Exchange. 
2. Multiple consumers can subscribe to the Queue to which the producer is publishing the messages to. 
3. All the consumers receive a copy of the message pushed by the producer.
4. It uses RabbitMQ Exchange of Fanout type to deliver same mesasge to multiple consumers

Steps to Run.

1. Pull rabbitmq:3-management Docker image from Dockerhub and run the image using 'docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management' command
2. In the .Net API project, run update-database to create the database on local MS SQL Server.
2. Rub Both .Net API poject and the 2 Consumer Console application paralelly as Multiple project startup in Visual Studio
3. Add new products using the API and we should see the 2 console applications reading the same messages from RabbitMQ and printing it on the console.
