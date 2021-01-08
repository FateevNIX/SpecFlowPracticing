Feature: SearchForProductsFeature
	After I search for the product
	It shown on the Search results page

@tearDown
Scenario Outline: Search for products
	Given I navigate to the Home page
	When I enter the <ProductName> into search input
	And Click on search button
	Then The search result page is shown
	And Results contains <ProductName>
	Examples: 
	| ProductName |
	| Blouse      |
	| Dress       |