Feature: SearchSkillNegative

Validate if user is able to search a skill, use filter and refine results.

Scenario: 01) Search an empty skill
	Given I search an empty skill
	Then All registered skills must be displayed successfully

Scenario: 02) Search skill with just space
	Given I search a skill with just space
	Then All registered skills must be displayed successfully

Scenario: 03) Search an empty skill from the result page
	Given I search an empty skill from the result page
	Then There will be no changes in the result page

Scenario: 04) Search an empty user from the result page
	Given I search an empty user from the result page
	Then There should be no results to display

Scenario: 05) Search with more than the number of allowed characters
	Given I search with more than the number of allowed characters
	Then The website should crash



