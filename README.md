# NatixisMovieRentalExercise

Answers to the exercise:

 * The app is throwing an error when we start, please help us. Also, tell us what caused the issue.

-> Answer: The error was caused because, when the database was initialized in AddDbContext, it, by default, initializes it with a scoped service lifetime, and, since RentalFeatures used the database, it could not be initialized as a singleton because it would have a larger service lifetime. Initializing the RentalFeatures service as scoped or initializing the database with a singleton service lifetime would solve the issue.


 * The rental class has a method to save, but it is not async, can you make it async and explain to us what is the difference?

 -> Answer: Now the method is async and can be executed without blocking the operations of the program and is better for scalability when receiving too many requests.


 * Please finish the method to filter rentals by customer name, and add the new endpoint.
 * We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
   Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!


 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.

-> Answer: The method selects all the information in the table, which might be a security issue since it exposes the ids and names of all records in the table. Also, the method extracts all records, if the table had too many entries, it would impact heavily the performance of the program, making the method to get the records using pagination would solve this issue.



 * No exceptions are being caught in this api, how would you deal with these exceptions?

 -> Answer: I would make it that the API responses can reflect if an error happened so that they can be properly communicated to the user and return the appropriate error code in the response of the request. For example:
 * I would add a validation to make sure when a new record is saved in the API, that all the inputted data is in the correct format and alert the user.
 * I would alert if there was an internal error when trying to save the changes to the database.



	## Challenge (Nice to have)
We need to implement a new feature in the system that supports automatic payment processing. Given the advancements in technology, it is essential to integrate multiple payment providers into our system.

Here are the specific instructions for this implementation:

* Payment Provider Classes:
    * In the "PaymentProvider" folder, you will find two classes that contain basic (dummy) implementations of payment providers. These can be used as a starting point for your work.
* RentalFeatures Class:
    * Within the RentalFeatures class, you are required to implement the payment processing functionality.
* Payment Provider Designation:
    * The specific payment provider to be used in a rental is specified in the Rental model under the attribute named "PaymentMethod".
* Extensibility:
    * The system should be designed to allow the addition of more payment providers in the future, ensuring flexibility and scalability.
* Payment Failure Handling:
    * If the payment method fails during the transaction, the system should prevent the creation of the rental record. In such cases, no rental should be saved to the database.
