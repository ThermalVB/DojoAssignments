SELECT `accounts`.`AccountId`,
    `accounts`.`FirstName`,
    `accounts`.`Last Name`,
    `accounts`.`Email`,
    `accounts`.`Password`,
    `accounts`.`Balance`,
    `accounts`.`CreatedAt`,
    `accounts`.`UpdatedAt`
FROM `bankaccounts`.`accounts`;

INSERT INTO `bankaccounts`.`accounts`
(`AccountId`,
`FirstName`,
`Last Name`,
`Email`,
`Password`,
`Balance`,
`CreatedAt`,
`UpdatedAt`)
VALUES
(<{FirstName: }>,
<{Last Name: }>,
<{Email: }>,
<{Password: }>,
<{Balance: }>,
<{CreatedAt: }>,
<{UpdatedAt: }>);

