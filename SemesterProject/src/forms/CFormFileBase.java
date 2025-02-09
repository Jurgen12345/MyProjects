package forms;
import data.*;
import java.io.File;
import java.util.Arrays;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import java.awt.event.KeyEvent;


public class CFormFileBase extends javax.swing.JFrame {

    private CDictionaryStringKey<String> Dict;
            
    public CFormFileBase() {
        initComponents();
        this.setTitle("File Base");
        this.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE); 
        Dict = new CDictionaryStringKey<>(true); 
        
    }

    public void Build(){ 
         
        File oStartFolder = new File(this.txtFolder.getText());
        
        this.txtTreeView.setText(""); 
        Recurse(oStartFolder, 1);
     }
    
    protected void Display(String p_sNodeName, Boolean p_bIsDirectory, int p_nDepth,long size)
    {
        String sIdentation = "";
        if ((p_nDepth -1) >=0)
        {
            char[] sCharArray = new char[(p_nDepth-1)*4];
            Arrays.fill(sCharArray, ' ');
            sIdentation = new String(sCharArray);  
        }
        
        String sNodeDescription;
        if (p_bIsDirectory)
            sNodeDescription = sIdentation + "Directory: " + p_sNodeName;
        else
            sNodeDescription = sIdentation + "File: " + p_sNodeName + "| size : " +size ;
        System.out.println(sNodeDescription);        
        
        this.txtTreeView.setText(this.txtTreeView.getText() + "\r\n" + sNodeDescription);
    }
    
    private void Recurse(File oFile, int p_nDepth)
    {
        
        File[] oFileEntries = oFile.listFiles();
        if (oFileEntries != null)
            for (File oFileEntry: oFileEntries) 
            {
                String  sNodeName       = oFileEntry.getName();
                Boolean bIsDirectory    = oFileEntry.isDirectory();
                
                Display(sNodeName, bIsDirectory, p_nDepth,oFileEntry.length());
                this.Dict.setValue(Long.toString(oFileEntry.length()),sNodeName);
                
                if (bIsDirectory)
                    Recurse(oFileEntry, p_nDepth + 1);
                 
               
            };
    }
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        lblFolderView = new javax.swing.JLabel();
        btnBuild = new javax.swing.JButton();
        lblFileInformationList = new javax.swing.JLabel();
        txtFolder = new javax.swing.JTextField();
        lblFolder = new javax.swing.JLabel();
        btnFolderDialog = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        txtTreeView = new javax.swing.JTextArea();
        jScrollPane2 = new javax.swing.JScrollPane();
        txtInfoView = new javax.swing.JTextArea();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        lblFolderView.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        lblFolderView.setText("File System Tree View");

        btnBuild.setText("Build");
        btnBuild.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnBuildActionPerformed(evt);
            }
        });

        lblFileInformationList.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        lblFileInformationList.setText("File Information List View");

        lblFolder.setText("Start Folder:");

        btnFolderDialog.setText("...");
        btnFolderDialog.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnFolderDialogActionPerformed(evt);
            }
        });

        txtTreeView.setColumns(20);
        txtTreeView.setRows(5);
        jScrollPane1.setViewportView(txtTreeView);

        txtInfoView.setColumns(20);
        txtInfoView.setRows(5);
        jScrollPane2.setViewportView(txtInfoView);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(20, 20, 20)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lblFolderView)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(lblFileInformationList)
                        .addGap(64, 64, 64))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 305, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(jScrollPane2))
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                .addGroup(layout.createSequentialGroup()
                                    .addComponent(txtFolder, javax.swing.GroupLayout.PREFERRED_SIZE, 402, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                    .addComponent(btnFolderDialog)
                                    .addGap(45, 45, 45)
                                    .addComponent(btnBuild, javax.swing.GroupLayout.PREFERRED_SIZE, 111, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addComponent(lblFolder, javax.swing.GroupLayout.PREFERRED_SIZE, 79, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addContainerGap(32, Short.MAX_VALUE))))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(lblFolder)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(txtFolder)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(btnFolderDialog, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(btnBuild, javax.swing.GroupLayout.PREFERRED_SIZE, 37, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lblFolderView)
                    .addComponent(lblFileInformationList))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 473, Short.MAX_VALUE)
                    .addComponent(jScrollPane1))
                .addGap(22, 22, 22))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void btnBuildActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBuildActionPerformed
        Build();
        
        CStringArray Keys = this.Dict.getKeys();
        CLongArray LongList = new CLongArray(32);
        
        for(String key:Keys.getArray()){
            LongList.Append(Long.parseLong(key));
        }
        
        CSortingAlgorithms.MergeSortLong(LongList);
        
        for(long Key:LongList.getArray()){
            String value = this.Dict.getValue(Long.toString(Key));
            String key = Key + "\r\n";
            this.txtInfoView.append(value + " : " + key);
        }
    }//GEN-LAST:event_btnBuildActionPerformed

    private void txtPathKeyPressed(java.awt.event.KeyEvent evt) {                                   
        if (evt.getKeyCode() == KeyEvent.VK_ENTER)
            Build();
    }   
    
    private void btnFolderDialogActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnFolderDialogActionPerformed
        JFileChooser oChooser = new JFileChooser();
        oChooser.setCurrentDirectory(new File("C:\\Users")); 
        oChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY); 
        oChooser.setDialogTitle("Please select a path");
        
        
        if (oChooser.showOpenDialog(null) == JFileChooser.APPROVE_OPTION)  
        {
            File oSelectedFolder = oChooser.getSelectedFile();
            this.txtFolder.setText(oSelectedFolder.getPath());
        }
    }//GEN-LAST:event_btnFolderDialogActionPerformed

    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(CFormFileBase.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(CFormFileBase.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(CFormFileBase.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(CFormFileBase.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new CFormFileBase().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnBuild;
    private javax.swing.JButton btnFolderDialog;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JLabel lblFileInformationList;
    private javax.swing.JLabel lblFolder;
    private javax.swing.JLabel lblFolderView;
    private javax.swing.JTextField txtFolder;
    private javax.swing.JTextArea txtInfoView;
    private javax.swing.JTextArea txtTreeView;
    // End of variables declaration//GEN-END:variables
}
