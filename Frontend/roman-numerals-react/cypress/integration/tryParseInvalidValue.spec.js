describe('Try Parse Invalid Roman Numeral Value', () => {
    it('Visit Home Page Roman Numerals', () => {
        cy.visit('/');

        cy.contains('Roman Numerals');

        cy.wait(1000);

        cy.get('#roman').type('V67', { delay: 150 }).should('have.value', 'V67');
        cy.get('#decimal').should('have.value', '');

        cy.get('#romanError').contains('Invalid Value. This is not a Roman Numeral.');
    });
});