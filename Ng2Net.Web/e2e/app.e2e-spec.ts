import { ConsultareWebPage } from './app.po';

describe('consultare-web App', function() {
  let page: ConsultareWebPage;

  beforeEach(() => {
    page = new ConsultareWebPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
