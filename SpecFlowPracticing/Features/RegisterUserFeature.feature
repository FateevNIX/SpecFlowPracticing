Feature: RegisterUserFeature
	this feature checks registration feature

@mytag
Scenario: Register user from Home Page
	Given I navigate to the Home page
	When I click on 'Sign in' button
	Then Authentication page is shown
	When I enter and submit new Email
	Then Registration page is shown
	When I fill in all required fields
		| Gender | FirstName | LastName    | Password | DayOfBirth | MonthOfBirth | YearOfBirth | AdressFirstName | AdressLastName | Adress         | City     | State | ZipCode | Phone    |
		| Mr.    | Alexandr  | Mercerovich | A123456  | 25         | June         | 1991        | Alex            | Mercer         | some street 42 | New York | Maine | 12345   | 12414124 |
	And Click on Register button
	Then User is succesfully registered