Feature: SentRequest

Validate "Sent Requests" features

Background: 
	Given I navigate to Sent Requests Page then Received Request Page


Scenario: 01) Withdraw Request
	Given I withdraw a request
	Then The request should be withrawn successfully

Scenario: 02) View Recipient's Profile
	Given I view the recipient's profile
	Then The recipient's profile should be displayed successfully

Scenario: 03) View Sent Service
	Given I view the sent service
	Then The sent service should be displayed successfully

Scenario: 04) Sort Sent Requests by Category
	Given I sort the sent requests by categories
	Then The sent requests should be sorted by categories successfully

Scenario: 05) Sort Sent Requests by Title
	Given I sort the sent requests by title
	Then The sent requests should be sorted by title successfully
	
Scenario: 06) Sort Sent Requests by Message
	Given I sort the sent requests by message
	Then The sent requests should be sorted by message successfully

Scenario: 07) Sort Sent Requests by Sender
	Given I sort the sent requests by sender
	Then The sent requests should be sorted by sender successfully

Scenario: 08) Sort Sent Requests by Status
	Given I sort the sent requests by status
	Then The sent requests should be sorted by status successfully

Scenario: 09) Sort Sent Requests by Type
	Given I sort the sent requests by type
	Then The sent requests should be sorted by type successfully

Scenario: 10) Sort Sent Requests by Date
	Given I sort the sent requests by date
	Then The sent requests should be sorted by date successfully
