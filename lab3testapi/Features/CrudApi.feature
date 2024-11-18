Feature: CrudApi


  Scenario: Get an existing booking
    Given I have a valid booking ID for GET
    When I send a GET request to the "/booking" endpoint
    Then the response status code for GET should be 200
    And the response should contain the booking details

   Scenario: Create a new booking
    Given  I have a valid booking payload
    When I send a POST request to the "/booking" endpoint
    Then the response status code for POST should be 200

   Scenario: Update an existing booking
    Given  I have a valid booking ID and update payload
    When I send a PUT request to the "/booking/{id}" endpoint
    Then the response status code for PUT should be 200

  Scenario: Delete an existing booking
    Given I have a valid booking ID for DELETE
    When I send a DELETE request to the "/booking/{id}" endpoint
    Then the response status code for DELETE should be 201