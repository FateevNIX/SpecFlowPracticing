﻿Feature: SimpleFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Search for product and add it to the cart
	Given I navigate to the home page
	When I typed "product name" into search field
	And I click on Search button
	Then Product is displayed among others
	| Name   | Size | Quantity | Price |
	| Blouse | M    | 2        | 100   |