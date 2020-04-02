namespace MyBehavior{
    public class BehaviorTree : BehaviorNode {
        
        public string Name{ get; set;}

        public string Domains{ get; set;}

        public bool load_xml(string pBuffer){
            
            return true;
        }

        public void load_properties_pars_attachments_children(string agentType, XmlNode node){

        }
    }
}