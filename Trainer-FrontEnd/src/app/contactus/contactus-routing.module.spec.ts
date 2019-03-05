import { ContactusRoutingModule } from './contactus-routing.module';

describe('ContactusRoutingModule', () => {
  let contactusRoutingModule: ContactusRoutingModule;

  beforeEach(() => {
    contactusRoutingModule = new ContactusRoutingModule();
  });

  it('should create an instance', () => {
    expect(contactusRoutingModule).toBeTruthy();
  });
});
