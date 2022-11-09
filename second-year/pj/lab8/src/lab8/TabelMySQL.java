package lab8;

import java.awt.BorderLayout;
import java.awt.Component;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JToolBar;
import java.awt.FlowLayout;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.ImageIcon;

import java.sql.*;

import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class TabelMySQL extends JFrame {

	private JPanel contentPane;
	private JTextField textId;
	private JTextField textNume;
	private JTextField textVarsta;
	private JTextField textRegister;
	private ResultSet rs;
	Statement sql;
	Connection con;
	private int nr_rows;
	private JButton btnFirst, btnPrevious, btnNext, btnLast, btnAdd, btnDelete, btnEdit, btnFind, btnSave, btnUndo;
	int id;
	String nume;
	int varsta;
	boolean editare=false;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args){
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					TabelMySQL frame = new TabelMySQL();
					
					
					frame.conectareBD();
					frame.setVisible(true);
					frame.print();
					
				} catch (Exception e) {
					e.printStackTrace();
				}
				
			}
		});
	}
	
	public void print() throws SQLException {
		textId.setText(rs.getString(1));
		textNume.setText(rs.getString(2));
		textVarsta.setText(rs.getString(3));
		
		textRegister.setText(rs.getRow()+"/"+nr_rows);
		
		if(rs.getRow()==1) {
			btnFirst.setEnabled(false);
			btnPrevious.setEnabled(false);
		}
		else {
			btnFirst.setEnabled(true);
			btnPrevious.setEnabled(true);
		}
		
		if(rs.getRow()== nr_rows) {
			btnNext.setEnabled(false);
			btnLast.setEnabled(false);
		}
		else {
			btnNext.setEnabled(true);
			btnLast.setEnabled(true);
		}
	}
	
	public void conectareBD() throws SQLException{
		String url = "jdbc:mysql://localhost:3306/test";
		
		try {
			con = DriverManager.getConnection(url,"root","root");
			sql=con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE,ResultSet.CONCUR_UPDATABLE);
			//sql=con.createStatement();
			rs=sql.executeQuery("select * from persoane");
			nr_rows=0;
			while(rs.next()) {
				nr_rows++;
			}
			//rs.first();
			rs=sql.executeQuery("select * from persoane");
			rs.next();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	
	/**
	 * Create the frame.
	 * @throws SQLException 
	 */
	public TabelMySQL() throws SQLException {	
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(new BorderLayout(0, 0));
		
		JToolBar toolBar = new JToolBar();
		contentPane.add(toolBar, BorderLayout.NORTH);
		
		btnFirst = new JButton("");
		btnFirst.setEnabled(false);
		btnFirst.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				try {
					rs=sql.executeQuery("select * from persoane");
					rs.next();
					print();
					
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		toolBar.add(btnFirst);
		btnFirst.setIcon(new ImageIcon(TabelMySQL.class.getResource("MoveFirst.png")));
		
		btnPrevious = new JButton("");
		btnPrevious.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
					try {
						rs.previous();
						//int row=rs.getRow();
//						rs=sql.executeQuery("select * from persoane");
//						for(int i=1;i<row;i++)
//							rs.next();
						print();
					} catch (SQLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
			}
		});
		btnPrevious.setEnabled(false);

		toolBar.add(btnPrevious);
		btnPrevious.setIcon(new ImageIcon(TabelMySQL.class.getResource("MovePrevious.png")));
		
		textRegister = new JTextField();
		toolBar.add(textRegister);
		textRegister.setColumns(10);
		
		btnNext = new JButton("");
		btnNext.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					rs.next();
					print();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});

		toolBar.add(btnNext);
		btnNext.setIcon(new ImageIcon(TabelMySQL.class.getResource("MoveNext.png")));
		
		btnLast = new JButton("");
		btnLast.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				try {
					for(int i=rs.getRow();i<nr_rows;i++) rs.next();
					print();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				
			}
		});
		toolBar.add(btnLast);
		btnLast.setIcon(new ImageIcon(TabelMySQL.class.getResource("MoveLast.png")));
		
		
		btnAdd = new JButton("");
		btnAdd.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				Stare(2);
				
				textId.setText("");
				textNume.setText("");
				textVarsta.setText("");
				
			}
		});
		toolBar.add(btnAdd);
		btnAdd.setIcon(new ImageIcon(TabelMySQL.class.getResource("Add.png")));
		
		btnEdit = new JButton("");
		btnEdit.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				Stare(2);
				editare=true;
				
			}
		});
		toolBar.add(btnEdit);
		btnEdit.setIcon(new ImageIcon(TabelMySQL.class.getResource("Edit.png")));
		
		btnDelete = new JButton("");
		btnDelete.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				int result=JOptionPane.showConfirmDialog(null, "Sunteti sigur ca doriti sa stergeti persoana curenta?", "Confirmare stergere", JOptionPane.OK_CANCEL_OPTION);
			
				if(result==JOptionPane.OK_OPTION) {

					try {
						CallableStatement call = con.prepareCall("{call sterge(?)}");
						
						id=Integer.valueOf(textId.getText());
						call.setInt(1, id);
						
						call.execute();
						call.close();
					
						conectareBD();
						print();
					} catch (SQLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
				
					
				}
			}
		});
		toolBar.add(btnDelete);
		btnDelete.setIcon(new ImageIcon(TabelMySQL.class.getResource("Delete.png")));
		
		btnFind = new JButton("");
		btnFind.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String nume_cautat=JOptionPane.showInputDialog(null, "Nume:");
				try {
					rs.first();
					for(int i=1;i<=nr_rows;i++) {
						if(rs.getString("nume").equals(nume_cautat)) {
							print();
							break;
						}
						rs.next();
					}
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				
				
			}
		});
		toolBar.add(btnFind);
		btnFind.setIcon(new ImageIcon(TabelMySQL.class.getResource("find.jpg")));
		
		btnSave =  new JButton("");
		btnSave.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				Stare(1);
				id=Integer.valueOf(textId.getText());
				nume=textNume.getText();
				varsta=Integer.parseInt(textVarsta.getText());
		
				try {
					CallableStatement call = null;
					
					if(editare==false) {
						call=con.prepareCall("{call adaugare(?,?,?)}");
					}
					else {
						call=con.prepareCall("{call editare(?,?,?)}");
						editare=false;
					}
					call.setInt(1, id);
					call.setString(2, nume);
					call.setInt(3, varsta);
					
					call.execute();
					call.close();
					
					conectareBD();
					print();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				
				
			}
		});
		btnSave.setEnabled(false);
		toolBar.add(btnSave);
		btnSave.setIcon(new ImageIcon(TabelMySQL.class.getResource("save.jpg")));
		
		btnUndo = new JButton("");
		btnUndo.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				Stare(1);
				try {
					print();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		btnUndo.setEnabled(false);
		toolBar.add(btnUndo);
		btnUndo.setIcon(new ImageIcon(TabelMySQL.class.getResource("undo.jpg")));
		
		JPanel panel = new JPanel();
		contentPane.add(panel, BorderLayout.CENTER);
		panel.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));
		
		
		JPanel panel_1 = new JPanel();
		panel.add(panel_1);
		panel_1.setLayout(new BoxLayout(panel_1, BoxLayout.Y_AXIS));
		JLabel lblNewLabel = new JLabel("Id");
		panel_1.add(lblNewLabel);
		Component vs = Box.createVerticalStrut(20);
		panel_1.add(vs);
		
		JLabel lblNewLabel_1 = new JLabel("Nume");
		panel_1.add(lblNewLabel_1);
		Component vs1 = Box.createVerticalStrut(20);
		panel_1.add(vs1);
		
		JLabel lblNewLabel_2 = new JLabel("Varsta");
		panel_1.add(lblNewLabel_2);
		
		JPanel panel_2 = new JPanel();
		panel.add(panel_2);
		panel_2.setLayout(new BoxLayout(panel_2, BoxLayout.Y_AXIS));
		
		textId = new JTextField();
		panel_2.add(textId);
		textId.setColumns(10);
		Component vs2 = Box.createVerticalStrut(15);
		panel_2.add(vs2);
		
		textNume = new JTextField();
		panel_2.add(textNume);
		textNume.setColumns(10);
		Component vs3 = Box.createVerticalStrut(15);
		panel_2.add(vs3);
		
		textVarsta = new JTextField();
		panel_2.add(textVarsta);
		textVarsta.setColumns(10);
		
		
	}
	
	public void Stare(int stare) {
		if(stare==1) {
			btnSave.setEnabled(false);
			btnUndo.setEnabled(false);
			
			btnAdd.setEnabled(true);
			btnDelete.setEnabled(true);
			btnEdit.setEnabled(true);
			btnFind.setEnabled(true);
			btnFirst.setEnabled(true);
			btnNext.setEnabled(true);
			btnPrevious.setEnabled(true);
			btnLast.setEnabled(true);
		}
		else if(stare==2) {
			btnAdd.setEnabled(false);
			btnDelete.setEnabled(false);
			btnEdit.setEnabled(false);
			btnFind.setEnabled(false);
			btnFirst.setEnabled(false);
			btnNext.setEnabled(false);
			btnPrevious.setEnabled(false);
			btnLast.setEnabled(false);
			
			btnSave.setEnabled(true);
			btnUndo.setEnabled(true);
		}
	}
}
