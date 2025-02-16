/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/GUIForms/JFrame.java to edit this template
 */
package forms;

/**
 *
 * @author jurge
 */
public class CMainForm extends javax.swing.JFrame {

    private CFormEditor editor = null;
    private CFormFileBase filebase = null;
    private CFormHelpCenter helpcenter = null;
    private CFormKMS kms = null;
    private CFormCustomers customers = null;
    public CMainForm() {
        initComponents();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        editorButton = new javax.swing.JButton();
        helpcenterButton = new javax.swing.JButton();
        filebaseButton = new javax.swing.JButton();
        kmsButton = new javax.swing.JButton();
        CustomersButton = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jLabel1.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        jLabel1.setText("CS2015 Final Project");

        editorButton.setText("Editor");
        editorButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                editorButtonActionPerformed(evt);
            }
        });

        helpcenterButton.setText("Help Center");
        helpcenterButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                helpcenterButtonActionPerformed(evt);
            }
        });

        filebaseButton.setText("File Base");
        filebaseButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                filebaseButtonActionPerformed(evt);
            }
        });

        kmsButton.setText("KMS");
        kmsButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                kmsButtonActionPerformed(evt);
            }
        });

        CustomersButton.setText("Customers");
        CustomersButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                CustomersButtonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                    .addComponent(editorButton, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jLabel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(helpcenterButton, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(filebaseButton, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(kmsButton, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(CustomersButton, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addGap(18, 18, 18)
                .addComponent(editorButton)
                .addGap(18, 18, 18)
                .addComponent(helpcenterButton)
                .addGap(18, 18, 18)
                .addComponent(filebaseButton)
                .addGap(18, 18, 18)
                .addComponent(kmsButton)
                .addGap(18, 18, 18)
                .addComponent(CustomersButton)
                .addContainerGap(15, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void filebaseButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_filebaseButtonActionPerformed
        if(this.filebase == null)
            this.filebase = new CFormFileBase();
        this.filebase.setVisible(true);
    }//GEN-LAST:event_filebaseButtonActionPerformed

    private void editorButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_editorButtonActionPerformed
        if(this.editor == null)
            this.editor = new CFormEditor();
        this.editor.setVisible(true);
    }//GEN-LAST:event_editorButtonActionPerformed

    private void helpcenterButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_helpcenterButtonActionPerformed
        if(this.helpcenter == null)
            this.helpcenter = new CFormHelpCenter();
        this.helpcenter.setVisible(true);
    }//GEN-LAST:event_helpcenterButtonActionPerformed

    private void kmsButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_kmsButtonActionPerformed
        if(this.kms == null)
            this.kms = new CFormKMS();
        this.kms.setVisible(true);
    }//GEN-LAST:event_kmsButtonActionPerformed

    private void CustomersButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_CustomersButtonActionPerformed
        if(this.customers == null)
            this.customers = new CFormCustomers();
        this.customers.setVisible(true);
    }//GEN-LAST:event_CustomersButtonActionPerformed

    /**
     * @param args the command line arguments
     */
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
            java.util.logging.Logger.getLogger(CMainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(CMainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(CMainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(CMainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new CMainForm().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton CustomersButton;
    private javax.swing.JButton editorButton;
    private javax.swing.JButton filebaseButton;
    private javax.swing.JButton helpcenterButton;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JButton kmsButton;
    // End of variables declaration//GEN-END:variables
}
