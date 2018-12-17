import { AuthRoutingModule } from './auth-routing.module';

describe('LoginRoutingModule', () => {
  let loginRoutingModule: AuthRoutingModule;

  beforeEach(() => {
    loginRoutingModule = new AuthRoutingModule();
  });

  it('should create an instance', () => {
    expect(loginRoutingModule).toBeTruthy();
  });
});
