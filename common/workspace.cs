
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyBehavior{


    public class Workspace : Singleton<Workspace>{

        public enum EFileFormat {
            EFF_xml = 1,								//specify to use xml only
            EFF_bson = 2,								//specify to use bson only
            EFF_cpp = 4,								//specify to use cpp only
            EFF_default = EFF_xml | EFF_bson | EFF_cpp	//first try to use xml, if xml file doesn't exist, it tries the bson, then tries cpp
        };

        private bool m_bInited = false;
        private bool m_bRegistered = false; 
        private EFileFormat m_fileFormat = EFileFormat.EFF_xml;
        private Dictionary<string, BehaviorTree> m_behaviortrees = new Dictionary<string, BehaviorTree>();
        private Dictionary<string, Agent> m_Agents = new Dictionary<string, Agent>();
        private string m_szWorkspaceExportPath;

        public void AddAgent(string agentName, Agent agent)
        {
            Console.WriteLine("AddAgent" + agentName);
            if (agent != null)
            {
                this.m_Agents[agentName] = agent;
            }
            
        }

        public bool TryInit(){
            return true;

        }

        public bool Load(string relativePath, bool bForce = false){

            if (!this.IsValidPath(relativePath)) return false;

            TryInit();

            BehaviorTree pBT = null;

            string fullpath = relativePath; // TODO：完整路径，先这样写
            EFileFormat f = this.GetFileFormat();
            bool bLoadResult = false;
            if (pBT == null) {
                pBT = new BehaviorTree();
                m_behaviortrees[relativePath] = pBT;
            }

            if (f == EFileFormat.EFF_xml){
                bLoadResult = this.load_xml(fullpath, pBT);
            }
            return true;
        }

        private bool load_xml(string fullpath, BehaviorTree pBT){
            XDocument document = XDocument.Load(fullpath);
            if (document == null){
                return false;
            }
            bool bLoadResult = pBT.load_xml(document);

            return bLoadResult;
        }
        private bool IsValidPath(string relativePath) {
        //BEHAVIAC_ASSERT(relativePath);

        if (relativePath[0] == '.' && (relativePath[1] == '/' || relativePath[1] == '\\')) {
            // ./dummy_bt
            return false;

        } else if (relativePath[0] == '/' || relativePath[0] == '\\') {
            // /dummy_bt
            return false;
        }

        return true;
        }

        public BehaviorTree LoadBehaviorTree(string relativePath) {

            if (m_behaviortrees[relativePath] != null) return m_behaviortrees[relativePath];
            else {
                bool bOk = this.Load(relativePath, true);

                if (bOk) {
                    return m_behaviortrees[relativePath];
                }
            }

            return null;
        }

        public string GetFilePath(){
            return m_szWorkspaceExportPath;
        }

        public void SetFilePath(string szExportPath){
            this.m_szWorkspaceExportPath = szExportPath;
        }

        public EFileFormat GetFileFormat(){
            return this.m_fileFormat;
        }

        public void SetFileFormat(EFileFormat ff) {
            this.m_fileFormat = ff;
        }

        public BehaviorTreeTask CreateBehaviorTreeTask(string relativePath){
            BehaviorTree bt = null;
            if (this.m_behaviortrees.ContainsKey(relativePath)){
                bt = this.m_behaviortrees[relativePath];
            }
            else{
                bool bOk = this.Load(relativePath);
                if (bOk){
                    bt = this.m_behaviortrees[relativePath];
                }
            }
            BehaviorTreeTask behaviorTask = null;
            if (bt != null){
                behaviorTask = (BehaviorTreeTask)bt.CreateAndInitTask();
            }
            return behaviorTask;
        }

        /// <summary>
        /// Loop for per frame.
        /// </summary>
        public void Update(){

            foreach(Agent agent in this.m_Agents.Values){
                agent.btExec();
            }
        }
    }
}