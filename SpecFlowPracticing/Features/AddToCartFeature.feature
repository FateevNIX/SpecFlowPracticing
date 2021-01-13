Feature: AddToCartFeature
	Check adding products to cart

@someTag
Scenario: Adding several products to cart
	Given I navigate to the Home page
	When I search for the Blouse
	Then The search result page is shown
	And Results contains Blouse
	When I click on More button for first product
	Then Product details page is shown
	When I select Quantity, Size, and Colour
		| Quantity | Size | Colour |
		| 3        | L    | Black  |
	And I click on 'Add to cart' button
	Then "Product successfully added to your shopping cart" modal is shown
	#When I click "Continue shopping" button
	#Then Product details page is shown
	#When I search for the Dress
	#Then The search result page is shown
	#And Results contains Printed Summer Dress
	#When I click on More button for first product
	#Then Product details page is shown
	#When I select Quantity, Size, and Colour
	#	| Quantity | Size | Colour |
	#	| 5        | M    | Orange |
	#And I click on "Add to cart" button
	#Then "Product successfully added" modal is shown
	#When I click "Proceed to checkout" button
	#Then Cart page is shown
	#And It has next products with properties
	#| ProductName          | Colour | Size | UnitPrice | Quantity | TotalPrice |
	#| Blouse               | Black  | M    | $27.00    | 3        | $81.00     |
	#| Printed Summer Dress | Orange | L    | $28.98    | 5        | $144.90    |
	