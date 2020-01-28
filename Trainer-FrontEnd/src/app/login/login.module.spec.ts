import { LoginModule } from './login.module';

describe('ArticlesModule', () => {
  let articlesModule: LoginModule;

  beforeEach(() => {
    articlesModule = new LoginModule();
  });

  it('should create an instance', () => {
    expect(articlesModule).toBeTruthy();
  });
});
