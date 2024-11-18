Feature: Comic

Scenario: Get an existing comic img
    Given I have a valid payload for GET
    When I send a GET request
    Then the response status code should be 200
