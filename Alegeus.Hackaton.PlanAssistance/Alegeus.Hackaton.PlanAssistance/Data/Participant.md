# Participant Class

## Description
The `Participant` class represents claims related to participant transactions within the Alegeus system. It includes various fields that provide information about the transaction, such as transaction date, service start date, service end date, and transaction type.

## Fields
- `TpaId`: A unique identifier used to identify your admin instance. ...
- `EmployerId`: Unique identifier for the employer. Note: WealthCare Admin assigns the 3-character prefix; ...
- `LastName`: The last name of the claimant.
- `FirstName`: The first name of the claimant.
- `SocSecNum`: Depending on the CardholderTypeCde, this will be the employee ID or the dependent ID ...
- `NamePrefix`: The prefix for the claimant’s name. Valid values are Mr., Mrs., Ms., Dr., and Rev.
- `Initial`: The middle initial of the claimant.
- `CardholderTypeCde`: Cardholder Type Cde: Employee = 1, Dependent = 2
- `CardNum`: Card Proxy Number
- `Claims`: List of claims that the participant has submitted on their participant portal or mobile app