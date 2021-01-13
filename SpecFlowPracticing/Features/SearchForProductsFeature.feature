Feature: SearchForProductsFeature
	After I search for the product
	It shown on the Search results page

@someTag
Scenario Outline: Search for products (with use of Outline)
	Given I navigate to the Home page
	When I search for the <ProductName>
	Then The search result page is shown
	And Results contains <ProductName>
	When I click on More button for first product
	Then Product details page is shown
	And Product has specific <FullName> and <Price>

	Examples:
		| ProductName | FullName             | Price |
		| Blouse      | Blouse               | 27.00 |
		| Dress       | Printed Summer Dress | 28.98 |

@someTag
Scenario: Search for product
	Given I navigate to the Home page
	When I search for the Blouse
	Then The search result page is shown
	And Results contains Blouse
	When I click on More button for first product
	Then Product details page is shown
	And Product has specific Blouse and 27.00

#doesn't work. looks like it's because of warning that SpecFlow.Plus.Excel requires specFlow 
#version more than 2.32 and less than 2.4.0, but my version is 3.5.14. 
#@someTag
#Scenario Outline: Search for products (with use of Excel examples)
#	Given I navigate to the Home page
#	When I search for the <ProductName>
#	Then The search result page is shown
#	And Results contains <ProductName>
#	When I click on More button for first product
#	Then Product details page is shown
#	And Product has specific <FullName> and <Price>
#	
#@source:data.xlsx
#Examples:
#|ProductName|FullName|Price| 