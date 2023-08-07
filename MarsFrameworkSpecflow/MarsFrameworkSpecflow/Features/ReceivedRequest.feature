Feature: ReceivedRequest

Validate "Received Request" features

Background: 
	Given I navigate to Manage Requests Page then Received Request Page

@tag1
Scenario: 01) Accept Request
	Given I accept a new request
	Then The new request should be accepted successfully

Scenario: 02) Decline Request
	Given I decline a new request
	Then The new request should be declined successfully

Scenario: 03) View Sender's Profile
	Given I view the sender's profile
	Then The sender's profile should be displayed successfully

Scenario: 04) View Requested Service
	Given I view the requested service
	Then The requested service should be displayed successfully

Scenario: 05) Sort by Category
	Given I sort the requests by categories
	Then The requests should be sorted by categories successfully

Scenario: 06) Sort by Title
	Given I sort the requests by title
	Then The requests should be sorted by title successfully
	
Scenario: 07) Sort by Message
	Given I sort the requests by message
	Then The requests should be sorted by message successfully

Scenario: 08) Sort by Sender
	Given I sort the requests by sender
	Then The requests should be sorted by sender successfully

Scenario: 09) Sort by Status
	Given I sort the requests by status
	Then The requests should be sorted by status successfully

Scenario: 10) Sort by Type
	Given I sort the requests by type
	Then The requests should be sorted by type successfully

Scenario: 11) Sort by Date
	Given I sort the requests by date
	Then The requests should be sorted by date successfully
