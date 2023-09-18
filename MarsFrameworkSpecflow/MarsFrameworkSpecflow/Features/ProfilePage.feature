Feature: ProfilePage

As a seller, I would like to sign up to MarsQA portal and add languages that I know.
So people seeking for some skills can look into it.

@languageBinding
Scenario Outline: Add language on my profile
	Given I add a new language record, '<Language>', '<Language Level>'
	Then The new language record should be added successfully, '<Language>', '<Language Level>'

Examples: 
	| Language | Language Level   |
	| Filipino | Native/Bilingual |
	| English  | Basic            |
	| Spanish  | Basic            |
	| French   | Fluent           |
	| Mandarin | Conversational   |
	#can only accept up to 4 

#Scenario: Edit a language on my profile
#	Given I edit the last language added
#	Then The language should be edited successfully
#
#Scenario: Delete a language on my profile
#	Given I delete the last added language
#	Then The language should be deleted successfully
# 
