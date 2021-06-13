describe('Open Page roman Numerals', () => {
    it('Visit Home Page Roman Numerals', () => {
        cy.visit('/');

        cy.contains('Roman Numerals');

        cy.wait(2000);

        cy.get('#roman').type('MMMDCCCLXXXVIII', { delay: 100 }).should('have.value', 'MMMDCCCLXXXVIII');
        cy.get('#decimal').should('have.value', '3888');
    });
});
