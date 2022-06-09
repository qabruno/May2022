Feature: TMFeature
As a TurnUp portal admin
I would like to create, edit and delete time and material records
So that I can manage employees' time and material successfully


@Create
Scenario: 1 create time and material record with valid details
	Given I logged into turnup portal successfully 
	When I navigate to time and material page
	When I create a time and material record
	Then the record should be created successfully

	@Edit
Scenario Outline: 2 edit existing time and material record
	Given I logged into turnup portal successfully
	When I navigate to time and material page
	When I update '<Description>', '<Code>', '<Price>' on an existing time and material record
	Then the record should have the updated '<Description>', '<Code>', '<Price>'

	Examples: 
	| Description  | Code    | Price    |
	| Keyboard     | May2022 | $16.00   |
	| Pen          | Phone   | $1500.00 |
	| EditedRecord | Portal  | $49.00   |


