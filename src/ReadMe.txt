Swagger UI available by appending to /swagger to the root route (i.e. https://localhost:44310/swagger/index.html)

Unit tests are just a small sample set

For simplicity I included the Domain models in the DAL, but typically on something of larger scope I would separate those into their own project for reuse

Simple logging goes into a log file that is held in RevealTripScheduler/Logs folder


Questions
1.	What URL would you use to fetch a list of 10 trip for a day in the pending status?
	I would add a url like https://localhost:44310/travelapi/trips?pageNo=1&pageSize=50 to make it simple.  Querystring the page and size info then accept those as parameters to a new controller action.  I would then need to build out some custom queries to utilize those parameters.

2.	What URL would you use to cancel a trip?
	I set up the cancel to work as a post using url https://localhost:44310/travelapi/trips/3 where 3 is the id of the trip to be canceled.  Using a tool like Postman you can easily test this.
3.	What would you do if this was in production being used by 3rd parties and you needed to change the interface to support a new feature?
	Since this assessment was purely an api project, I will answer from that standpoint (with the assumption that this feature is viable for our app).  
		First I would break the feature down into component ideas (front end, middle-tier, backend).
		Second I would assess the middle-tier components for their api implications
		Third I would design the needed api components and the tests that would likely need to be written
		Lastly I would actually write the components and their tests


Postman collection for a few test scripts 