Feature: CheckAdvertismentsFeature
	This feature tests the autoscrolling of advertisment on Home Page

@mytag
Scenario: Check advertisment to scroll to second one
	Given I navigate to the Home page
	When I wait for advertisment to be visible

Scenario Outline: Check that scroll advertisment is shows every advertisement it has
	Given I navigate to the Home page
	When I wait for <NumberOfAdvertisment> advertisment to be visible
	Examples:
	| NumberOfAdvertisment |
	| 1                    |
	| 2                    |
	| 3                    |