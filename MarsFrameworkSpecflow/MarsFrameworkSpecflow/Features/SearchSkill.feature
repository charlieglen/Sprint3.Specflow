Feature: SearchSkill
Validate if user is able to search a skill, use filter and refine results.


Background: 
	Given I search a skill from the profile page


Scenario: 01) View searched skill
	Given I view the main category
	When I view the subcategory
	Then The searched skill should be displayed successfully

Scenario: 02) Search user from result
	Given I search a user from the results page
	Then The searched user should be displayed successfully

Scenario: 03) Search skill from result
	Given I search a skill from the results page
	Then The searched skill should be display successfully

Scenario: 04) Filter skills by Location - Online
	Given I filter the skills by Location - Online
	Then All skills with online location should be displayed successfully

Scenario: 05) Filter skills by Location - Onsite
	Given  I filter the skills by Location - Onsite
	Then All skills with onsite location should be dispalayed successfully

Scenario: 06) Cancel location filter
	Given I cancel the location filter
	Then All results should be displayed successfully

Scenario: 07) Verify number of results per page
	Given I change the default number of results per page
	Then The new number of results should match successfully