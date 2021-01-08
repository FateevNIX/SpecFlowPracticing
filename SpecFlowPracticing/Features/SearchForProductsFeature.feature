Feature: SearchForProductsFeature
	After I search for the product
	It shown on the Search results page

@mytag
Scenario Outline: Search for products
	Given I navigate to the Home page
	When I enter the <ProductName> 
	And Click on search button
	Then The search result page is shown
	And Results contains <ProductName>
	Examples: 
	| ProductName |
	| Blouse      |
	| Dress       |