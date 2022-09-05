Feature: Verify Journey Planner Scenarios

Background: 
	Given the user lands on the TFL plan a journey page
@MyTest
Scenario: Successfully plan a journey with valid details
	When the user enter valid from location
	And the user enter valid destination
	And the user click on plan my journey button
	Then the user should be redirected to journey result page with details
@MyTest
Scenario: Failed to plan a journey with invalid details
	When the user enter invalid travel details
	And the user click on plan my journey button
	Then the user should be redirected to journey result page
	And the user should see "Journey planner could not find any results to your search. Please try again"
@MyTest
 Scenario: Failed to plan a journey with Empty values
	When click on plan my journey button without entering any travel details
	Then the user should see validation error message
@MyTest	
Scenario: Successfully plan a journey based on arrival time
	When the user enter valid from location
	And the user enter valid destination
	And the user select arriving option to plan the journey
	And the user click on plan my journey button
	Then the user should be redirected to journey result page with details
@MyTest
Scenario: Successfully Edit a journey
	When the user decided to edit the journey
	And the user click on the edit journey link
	And the user update the journey details
	And the user click on plan my journey button
	Then the user should be redirected to journey result page with updated details
